-- 在表plist的列表中查找k
local function search(k,plist)
    for i = 1, #plist do
        local v = plist[i][k]
        if v then
            return v
        end
    end
end

local function create(...)
    local c = {} --新类
    local parents = {...} --父类列表

    --在父类列表中查找类缺失的方法
    setmetatable(c,{__index = function (_,k)
        --print(t)
        --print(k)
        return search(k,parents)
    end})
    c.__index = c

    --为新类定义一个新的构造函数
    function c:new(o)
        o = o or {}
        setmetatable(o,c)
        return o
    end

    c.value = 1
    function c:func()
        print(self.value)
    end

    return c
end

Name = {}
function Name:getName()
    return self.name
end

function Name:setName(n)
    if self then
        --print("self:"..tostring(self))
    end
    if n then
        print(n)
    end

    if type(self) == "table" then
        self.name = n
    end
    --self.name = n
end

local School = {}
School.address = "蠡湖大道"
function School:getLevel()
    return self.level
end
function School:setLevel(n)
    self.level = n
end
--类
local sc  = create(Name,School)

local ASc = sc:new()
local ASc1 = sc:new()
--print(ASc)
-- print(ASc.value1)
-- print(sc)
-- ASc.setName("弋阳县高级中学")
-- -- ASc:setName("弋阳县高级中学")
-- ASc:setLevel("省重点高中")


-- print(ASc.address)
-- print(ASc1.address)

-- print(ASc.value)
-- print(ASc1.value)
-- print(ASc:getName())
-- print(ASc:getLevel())

-- local User = ASc:new(nil)

-- function User:getLevel()
--     return "研究生"
-- end
-- User:setName("巨人网络")

-- print(User:getName())
-- print(User:getLevel())

-- local t = {}
-- t[2.1] = 2
-- t[2.00000] = 2.1

-- print(t[2])
-- print(t[2.1])
-- for i = 2, 2.1, 0.1 do
--     print(t[i])
-- end

-- 函数是第一类值（

-- io.lines()

local s = "hello world from Lua aaaa+a000saf"
for w in string.gmatch(s, "%a+") do
    print(w)
end
-- string.gmatch()