using System;

namespace DevTools.Plugin.CodeLines.BLL
{
    public class ProgressEventArgs : EventArgs
    {
        public int MainMaximum { get; set; }
        public int MainValue { get; set; }
        public int SubMaximum { get; set; }
        public int SubValue { get; set; }
        public string MainMessage { get; set; }
        public string SubMessage { get; set; }

        public ProgressEventArgs()
        {
            this.MainMessage = string.Empty;
            this.MainMaximum = 1;
            this.MainValue = 0;

            this.SubMessage = string.Empty;
            this.SubMaximum = 1;
            this.SubValue = 0;
        }
    }
}
