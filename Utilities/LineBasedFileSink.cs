using Serilog.Core;
using Serilog.Events;

namespace SmartHealthAPI.Utilities
{
    public class LineBasedFileSink : ILogEventSink
    {
        private readonly object _syncRoot = new();
        private readonly int _maxLines;
        private int _currentLineCount = 0;
        private int _fileIndex = 1;
        private string _baseFilePath;
        private string _currentDate;
        private string _filePath;

        public LineBasedFileSink( string baseFilePath, int maxLines )
        {
            _baseFilePath = baseFilePath;
            _maxLines = maxLines;
            _currentDate = DateTime.UtcNow.ToString("yyyyMMdd");
            _filePath = $"{_baseFilePath}-{_currentDate}-{_fileIndex}.log";
            if (File.Exists(_filePath))
            {
                _currentLineCount = File.ReadAllLines(_filePath).Length + 1;
                while (_currentLineCount >= _maxLines)
                {
                    _fileIndex++;
                    _filePath = $"{_baseFilePath}-{_currentDate}-{_fileIndex}.log";
                    if (File.Exists(_filePath))
                        _currentLineCount = File.ReadAllLines(_filePath).Length + 1;
                    else
                        _currentLineCount = 0;
                }
            }
        }

        public void Emit( LogEvent logEvent )
        {
            lock (_syncRoot )
            {
                string today = DateTime.UtcNow.ToString("yyyyMMdd");

                if( _currentDate != today )
                {
                    _currentDate = today;
                    _fileIndex = 1;
                    _currentLineCount = 0;
                }

                if( _currentLineCount >= _maxLines )
                {
                    _fileIndex++;
                    _currentLineCount = 0;
                }

                _filePath = $"{_baseFilePath}-{_currentDate}-{_fileIndex}.log";
                var timestamp = logEvent.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
                var timeZoneOffset = TimeZoneInfo.Local.BaseUtcOffset.ToString("hh\\:mm");
                var logLevel = logEvent.Level.ToString().Substring(0, 3).ToUpper();
                var logMessage = logEvent.RenderMessage();
                var formattedLog = $"{timestamp} {timeZoneOffset} [{logLevel}] {logMessage}" + Environment.NewLine;
                //var formattedLog = $"{_currentLineCount} {timestamp} {timeZoneOffset} [{logLevel}] {logMessage}" + Environment.NewLine;
                File.AppendAllText(_filePath, formattedLog);
                _currentLineCount++;
            }
        }
    }
}
