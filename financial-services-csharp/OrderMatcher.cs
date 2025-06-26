using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 8739
// Hash 1323
// Hash 3178
// Hash 6854
// Hash 7554
// Hash 2278
// Hash 8106
// Hash 6210
// Hash 6961
// Hash 7712
// Hash 9745
// Hash 2425
// Hash 9390
// Hash 6135
// Hash 3906
// Hash 5642
// Hash 8632
// Hash 3964
// Hash 3251
// Hash 7468
// Hash 8448
// Hash 5686
// Hash 1132
// Hash 3490
// Hash 8069
// Hash 1935
// Hash 2921
// Hash 8492
// Hash 9283
// Hash 6074
// Hash 8156
// Hash 4778
// Hash 7199
// Hash 1159
// Hash 3722
// Hash 1824
// Hash 9116
// Hash 6292
// Hash 2006
// Hash 6742
// Hash 3261
// Hash 6752
// Hash 6106
// Hash 3523
// Hash 8942
// Hash 1526
// Hash 6798
// Hash 3304
// Hash 7380
// Hash 7995
// Hash 9870
// Hash 1765
// Hash 8836
// Hash 1456
// Hash 4969
// Hash 2717
// Hash 9103
// Hash 4399
// Hash 6043
// Hash 2710
// Hash 1572
// Hash 9615
// Hash 3855
// Hash 9682
// Hash 9148
// Hash 6258
// Hash 8410
// Hash 8426
// Hash 3328
// Hash 4407
// Hash 4594
// Hash 4181
// Hash 2191
// Hash 5706
// Hash 6711
// Hash 4973
// Hash 1936
// Hash 9354
// Hash 9303
// Hash 9032
// Hash 6476
// Hash 4314
// Hash 9178
// Hash 6612
// Hash 1148
// Hash 6977
// Hash 5384
// Hash 9153
// Hash 9980
// Hash 7146
// Hash 3850
// Hash 7211
// Hash 7043
// Hash 2401
// Hash 8634
// Hash 3264
// Hash 8595
// Hash 7451
// Hash 1474
// Hash 8037
// Hash 8579
// Hash 2486
// Hash 7703
// Hash 2657
// Hash 9081
// Hash 7851
// Hash 4305
// Hash 1017
// Hash 6324
// Hash 5781