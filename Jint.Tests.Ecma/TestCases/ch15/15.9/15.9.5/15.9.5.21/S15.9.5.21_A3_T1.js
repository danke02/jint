// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * The Date.prototype.getUTCMinutes property "length" has { ReadOnly, DontDelete, DontEnum } attributes
 *
 * @path ch15/15.9/15.9.5/15.9.5.21/S15.9.5.21_A3_T1.js
 * @description Checking ReadOnly attribute
 */

x = Date.prototype.getUTCMinutes.length;
Date.prototype.getUTCMinutes.length = 1;
if (Date.prototype.getUTCMinutes.length !== x) {
  $ERROR('#1: The Date.prototype.getUTCMinutes.length has the attribute ReadOnly');
}


