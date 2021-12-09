helper.dom.ready(function () {

	var jsro = new Thinfinity.JsRO();
	var ro = null;

	jsro.on('model:ro', 'created', function () {
		ro = jsro.model.ro;
	});

	// Handles ro.Events['getJSON'] 
	jsro.on('ro', 'getJSON', function () {
		ro.stringdata = 'hello world';
	});


});
