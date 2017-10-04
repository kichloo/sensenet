﻿using System;
using System.Collections.Generic;
using System.IO;

namespace SenseNet.Search
{
    public interface IIndexingActivityStatus
    {
        int LastActivityId { get; set; }
        int[] Gaps { get; set; }
    }
    public class IndexingActivityStatus : IIndexingActivityStatus
    {
        public static IndexingActivityStatus Startup => new IndexingActivityStatus { Gaps = new int[0], LastActivityId = 0 };
        public int LastActivityId { get; set; }
        public int[] Gaps { get; set; }
    }

    public interface IIndexingEngine
    {
        bool Running { get; }

        void Start(TextWriter consoleOut);
        void ShutDown();
        void ClearIndex();

        IIndexingActivityStatus ReadActivityStatusFromIndex();
        void WriteActivityStatusToIndex(IIndexingActivityStatus state);

        void WriteIndex(IEnumerable<SnTerm> deletions, IEnumerable<DocumentUpdate> updates, IEnumerable<IndexDocument> addition);
    }
}
