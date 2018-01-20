(function ($) {
	$.deferredClosure = function (deferredClosure) {
		var deferred = new $.Deferred();
		deferredClosure(deferred);
		return deferred;
	}
}(jQuery));