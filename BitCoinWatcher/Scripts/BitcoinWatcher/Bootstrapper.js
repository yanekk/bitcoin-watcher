var BitcoinWatcher = BitcoinWatcher || {};
BitcoinWatcher.Bootstrapper = BitcoinWatcher.Bootstrapper || {};

BitcoinWatcher.Bootstrapper.initialize = function() {
    ko.applyBindings(new BitcoinWatcher.ViewModels.BitcoinWatcherViewModel());
}