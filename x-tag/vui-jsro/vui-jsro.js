xtag.register('vui-gk', {
    'content':'',
    'lifecycle': {
        'inserted': function () {
            startJsRO(this.id);  
        }
    }
});
    
function startJsRO(controlId) {
  var jsro = new Thinfinity.JsRO();
  var ro = null;
  jsro.on('model:ro', 'created', function () {
    ro = jsro.model.ro;
  });
  
  // Handles ro.Events['getJSON'] 
  jsro.on('ro', 'getJSON', function () { 
    ro.myJSON = '{"name":"John", "age":30, "car":null}'; 
  }); 
 
};

