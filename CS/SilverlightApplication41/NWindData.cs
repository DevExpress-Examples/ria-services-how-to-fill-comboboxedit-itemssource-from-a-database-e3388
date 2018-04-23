using System;
using System.Collections.Generic;
using System.Linq;
using SilverlightApplication41.Web;
using System.Threading;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightApplication41 {
    public static class NWindData {
        static EventHandler loaded;
        static bool loadingDone;
        static AutoResetEvent loadingDoneUnlock = new AutoResetEvent(true); // mutex, protect loadingDone and loaded
        static bool loadingStarted;
        static AutoResetEvent loadingStartedUnlock = new AutoResetEvent(true); // mutex, protect loadingStarted
        static NWindContext dc = new NWindContext();
        static int tablesCount = 0;
        static int tablesLoaded = 0;
        public static void Load() {
            loadingStartedUnlock.WaitOne();
            if (!loadingStarted) {
                loadingStarted = true;
                Thread thread = new Thread(new ThreadStart(StartLoading));
                thread.Start();
            }
            loadingStartedUnlock.Set();
            loadingDoneUnlock.WaitOne();
            if (loadingDone) {
                if (loaded != null) loaded(typeof(NWindData), EventArgs.Empty);
                loaded = null;
            }
            loadingDoneUnlock.Set();
        }
        private static void StartLoading() {
            tablesCount = 1;
            dc.Load(dc.GetProductsQuery(), new Action<LoadOperation<Product>>(TLoaded), null);
        }
        public static event EventHandler Loaded {
            add {
                loadingDoneUnlock.WaitOne();
                loaded += value;
                loadingDoneUnlock.Set();
            }
            remove {
                loadingDoneUnlock.WaitOne();
                loaded -= value;
                loadingDoneUnlock.Set();
            }
        }

        static void TLoaded(LoadOperation<Product> op) {
            TableLoaded();
        }
        private static void TableLoaded() {
            if (++tablesLoaded >= tablesCount) {
                loadingDoneUnlock.WaitOne();
                loadingDone = true;
                if (loaded != null) {
                    loaded(typeof(NWindData), EventArgs.Empty);
                    loaded = null;
                }
                loadingDoneUnlock.Set();
            }
        }
        public static EntitySet<Product> Products { get { return dc.Products; } }
    }
}
