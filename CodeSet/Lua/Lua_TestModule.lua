-- require "Mathtool"
print(package.path)
local a,b = string.gsub(debug.getinfo(1).short_src, "^(.+\\)[^\\]+$", "%1?.lua")
a = ";"..a
-- print(a)
package.path = package.path..a
-- print(package.path)
b = require ("mathtool")

b.func3()
local tmp = {1,2,3,4,6,6}
print(b.createTable(tmp))
-- b = require ("module")