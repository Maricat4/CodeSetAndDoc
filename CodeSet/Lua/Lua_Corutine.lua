-- local newProductor

-- local function productor()
--      local i = 0
--      while true do
--           i = i + 1
--           Send(i)     -- 将生产的物品发送给消费者
--      end
-- end

-- local function consumer()
--      while true do
--           local i = Receive()     -- 从生产者那里得到物品
--           print(i)
--      end
-- end

-- function Receive()
--      local status, value = coroutine.resume(newProductor)
--      return value
-- end

-- function Send(x)
--      coroutine.yield(x)     -- x表示需要发送的值，值返回以后，就挂起该协同程序
-- end

-- -- 启动程序
-- newProductor = coroutine.create(productor)
-- consumer()
-- require "Mathtool"
print(package.path)
local a,b = string.gsub(debug.getinfo(1).short_src, "^(.+\\)[^\\]+$", "%1?.lua")
a = ";"..a
-- print(a)
package.path = package.path..a
-- print(package.path)
b = require ("mathtool")

local coco = coroutine.create(function () print("hihi") end)
print(type(coco))
print(coroutine)

function  Func(...)
     Table1 = {...}
     for key, value in pairs(Table1) do
          print(value)
     end
     
end

Func(1,2,3)
print(Table1)
for key, value in pairs(Table1) do
     print(value)
end

print(AA)
for key, value in pairs(AA) do
     print(value)
end