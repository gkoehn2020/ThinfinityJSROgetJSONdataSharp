helper.dom.ready(function () {

	var jsro = new Thinfinity.JsRO();
	var ro = null;

	jsro.on('model:ro', 'created', function () {
		ro = jsro.model.ro;
	});

	// Handles ro.Events['getStringFromBrowser'] 
	jsro.on('ro', 'getStringFromBrowser', function () {
		ro.stringdata = 'hello world';
	});


});
