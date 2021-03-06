/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-60.js
 * @description Object.defineProperty - type of desc.value is different from type of name.value (8.12.9 step 6)
 */


function testcase() {

        var obj = {};

        obj.foo = 101; // default value of attributes: writable: true, configurable: true, enumerable: true

        Object.defineProperty(obj, "foo", { value: "abc" });
        return dataPropertyAttributesAreCorrect(obj, "foo", "abc", true, true, true);
    }
runTestCase(testcase);
