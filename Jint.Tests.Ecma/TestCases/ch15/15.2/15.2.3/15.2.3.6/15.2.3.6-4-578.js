/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-578.js
 * @description ES5 Attributes - [[Get]] field of inherited property of [[Prototype]] internal property is correct (String instance)
 */


function testcase() {
        var data = "data";
        try {
            Object.defineProperty(String.prototype, "prop", {
                get: function () {
                    return data;
                },
                set: function (value) {
                    data = value;
                },
                enumerable: true,
                configurable: true
            });
            var strObj = new String();

            return !strObj.hasOwnProperty("prop") && strObj.prop === "data";
        } finally {
            delete String.prototype.prop;
        }
    }
runTestCase(testcase);
