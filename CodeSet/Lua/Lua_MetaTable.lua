
local a,b = string.gsub(debug.getinfo(1).short_src, "^(.+\\)[^\\]+$", "%1?.lua")
a = ";"..a
-- print(a)
package.path = package.path..a
-- print(package.path)
local Set = require "Set"


-- local var = {}
-- print(getmetatable(var))
-- local var1 = {}
-- setmetatable(var,var1)
-- print(getmetatable(var))

Set.Mt.__index = function(mytable,key)
    --print("1")
    if key == 200 then
        return "metatable"
    else
        return nil
    end

end

--设置元表的相应方法
Set.Mt.__add = Set.union
Set.Mt.__mul = Set.intersection

local s1 = Set.new{10,20,30,50}
local s2 = Set.new{90,1,20,30}
-- print(getmetatable(s1))
-- print(getmetatable(s2))

-- local s3 = s1+s2
-- print(Set.tostring(s3))
-- print(Set.tostring(s1*s2))

print(s1[10],s2[200])

local mymetatable = {}
local mytable = setmetatable({key1 = "value1"}, { __newindex = mymetatable,__index = mymetatable })

print(mytable.key1)

mytable.newkey = "新值2"
print(mytable.newkey,mymetatable.newkey)

mytable["淦"] = "新值3"
print(mytable["淦"],mymetatable["淦"])

mytable.newkey1 = "新值2"
print(mytable.newkey1,mymetatable.newkey1)

-- for key, value in pairs(mymetatable) do
--     print(key..","..value)
-- end

-- mytable.key1 = "新值1"
-- print(mytable.key1,mymetatable.newkey1)


--

local function setdefault(t,d)
    local mt = {__index = function() return d end}
    setmetatable(t,mt)
end
local tab = {x = 10,y = 10}
print(tab.z,tab.x)
setdefault(tab,10)
print(tab.z,tab.x)
local mt ={z = 1000}
Mt = {z = 10000}
Mt.__index = Mt
setmetatable(tab,Mt)
print(tab.z,tab.x)


local function track(t)
    local proxy = {}
    local mt = {
        __index = function (_,k)
            print("*access to element "..tostring(k))
            return t[k]
        end,

        __newindex = function (_,k,v)
            print("*update of element "..tostring(k).."to"..tostring(v))
            t[k] = v
        end,

        __pairs = function ()
            return function (_,k)
                local nextkey,nextvalue = next(t,k)
                if nextkey ~= nil then
                    print("*traversing element "..tostring(nextkey))
                end
                return nextkey,nextvalue
            end
        end,

        __len = function ()
            return #t
        end
    }
    setmetatable(proxy,mt)
    return proxy
end

local t = {}

t = track(t)
t[2] = "hello"
t[3] = "world"
--print(t[2])
print(tostring(t))

for key, value in pairs(t) do
    
end