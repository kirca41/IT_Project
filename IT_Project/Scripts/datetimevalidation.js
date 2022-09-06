// <reference path="jquery.validate.js" />
// <reference path="jquery.validate.unobtrusive.js" /> 
$.validator.unobtrusive.adapters.addSingleVal("datetime", "now");
$.validator.addMethod("datetime", function (value, element, now) {
    var d1 = new Date(value);
    var d2 = new Date(now);
    return d1 >= d2;
});
