using System;
using System.Drawing;
using System.Timers;
using Klocman.Extensions;
using Klocman.Tools;

namespace TextToScreen.Controls
{
    public sealed class TextDisplayBoxChangePusher : IDisposable
    {
        private bool _canChange;
        private int _currentTicks;
        private Timer _intervalTimer = new Timer();
        private bool _isPushing;
        private float _pushFadeTime;
        private int _targetTicks;
        private ContentAlignment _tempAlign;
        private Color _tempBackColor;
        private Font _tempFont;
        private Color _tempForeColor;
        private Color _tempTargetForeColor;
        private string _tempText;

        public TextDisplayBoxChangePusher(TextDisplayBox source, TextDisplayBox target)
        {
            Source = source;
            Target = target;
            _intervalTimer.Enabled = false;
            _intervalTimer.Elapsed += OnElapsedEvent;
            _intervalTimer.AutoReset = true;

            _intervalTimer.Interval = TextDisplayBox.OutputScreenRefreshInterval;
        }

        public bool CanChange
        {
            get { return !_intervalTimer.Enabled || _canChange; }
            private set
            {
                if (_canChange != value)
                {
                    _canChange = value;
                    OnCanChangeChanged();
                }
            }
        }

        public bool IsPushing
        {
            get { return _intervalTimer.Enabled && _isPushing; }
            private set
            {
                if (_isPushing != value)
                {
                    _isPushing = value;
                    OnIsPushingChanged();

                    _intervalTimer.Enabled = value;
                }
            }
        }

        /// <summary>
        ///     Time from starting a change to it finishing in seconds. Half of this time is spent fading out, the other half is
        ///     fading in.
        ///     0.1s resolution is intended. An value below 0.1s is instant.
        /// </summary>
        public float PushFadeTime
        {
            get { return _pushFadeTime; }
            set
            {
                _pushFadeTime = value;
                _targetTicks = (int) (value*1000/_intervalTimer.Interval);
            }
        }

        /// <summary>
        ///     Returns what percentage of the current push has passed.
        ///     If there is no ongoing push returns -1.
        /// </summary>
        public int PushProgress
        {
            get
            {
                if (!IsPushing)
                    return -1;
                var halfPercent = (_currentTicks*50)/_targetTicks;
                return CanChange ? 50 - halfPercent : 50 + halfPercent;
            }
        }

        /// <summary>
        ///     Refresh rate in Hz when fading displays, default is 30Hz.
        /// </summary>
        public int RefreshRate
        {
            get { return (int) (1000.0/_intervalTimer.Interval); }
            set { _intervalTimer.Interval = 1000.0/value; }
        }

        public TextDisplayBox Source { get; private set; }
        public TextDisplayBox Target { get; private set; }
        private float TimePosition => _currentTicks/(float) _targetTicks;

        public void Dispose()
        {
            _intervalTimer.Dispose();
            _intervalTimer = null;
            _tempFont = null;
            Source = null;
            Target = null;
        }

        public event Action<TextDisplayBoxChangePusher> CanChangeChanged;
        public event Action<TextDisplayBoxChangePusher> IsPushingChanged;
        public event Action<TextDisplayBoxChangePusher, int> PushProgressChanged;

        public bool DelayedPush()
        {
            if (!CanChange)
                return false;

            if (PushFadeTime < 0.1f)
            {
                InstantPush();
                return true;
            }

            SetupSourceTempVars();

            if (!IsPushing)
            {
                _currentTicks = _targetTicks;
                CanChange = true;
                IsPushing = true;
            }
            return true;
        }

        /// <summary>
        ///     Stops ongoing delayed pushes if any.
        /// </summary>
        public void InstantPush()
        {
            SetupSourceTempVars();
            PushNewContentsToTarget();
            Target.LabelForeColor = Source.LabelForeColor;
            IsPushing = false;
            CanChange = true;
        }

        private void OnCanChangeChanged()
        {
            Source.SafeInvoke(() => { CanChangeChanged?.Invoke(this); });
        }

        private void OnElapsedEvent(object source, ElapsedEventArgs e)
        {
            if (CanChange)
            {
                if (--_currentTicks <= 0)
                {
                    CanChange = false;
                    PushNewContentsToTarget();
                }
            }
            else
            {
                if (++_currentTicks >= _targetTicks)
                {
                    CanChange = true;
                    IsPushing = false;
                }
            }

            PushTextAlphaChangeToTarget();
            OnPushProgressChanged();
        }

        private void OnIsPushingChanged()
        {
            Source.SafeInvoke(() =>
            {
                IsPushingChanged?.Invoke(this);
                OnPushProgressChanged();
            });
        }

        private void OnPushProgressChanged()
        {
            Source.SafeInvoke(() => { PushProgressChanged?.Invoke(this, PushProgress); });
        }

        private void PushNewContentsToTarget()
        {
            Target.SafeInvoke(() =>
            {
                Target.ShowText(_tempText, _tempFont, _tempAlign);
                Target.LabelBackColor = _tempBackColor;
            });
        }

        private void PushTextAlphaChangeToTarget()
        {
            Target.Invoke(new Action(PushTextDelegate), new object[] {});
        }

        private void PushTextDelegate()
        {
            Color c;
            if (CanChange && IsPushing) // Used in case background color changed
            {
                c = DrawingTools.ColorLerp(Target.LabelBackColor, _tempTargetForeColor, TimePosition);
            }
            else
            {
                c = DrawingTools.ColorLerp(_tempBackColor, _tempForeColor, TimePosition);
            }
            Target.LabelForeColor = c;
        }

        private void SetupSourceTempVars()
        {
            _tempFont = new Font(Source.LabelFont, Source.LabelFont.Style);
            _tempAlign = Source.TextAlign;
            _tempText = Source.LabelText;
            _tempBackColor = Source.LabelBackColor;
            _tempForeColor = Source.LabelForeColor;
            _tempTargetForeColor = Target.LabelForeColor;
        }
    }
}