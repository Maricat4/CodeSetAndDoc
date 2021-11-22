Stack = {}
function Stack:push(var)
    self[#self+1] = var
end
function Stack:pop()
    local var = self[#self]
    table.remove(self,#self)
    return var
end
function Stack:top()
    return self[#self]
end
function Stack:isempty()
    return #self == 0
end

function Stack:new()
    O = {}
    setmetatable(O,self)
    self.__index = self
    return O
end

-- --print(package.path)
-- local a,b = string.gsub(debug.getinfo(1).short_src, "^(.+\\)[^\\]+$", "%1?.lua")
-- package.path = package.path..";"..a
-- b = require ("mathtool")


-- local var = Stack:new()
-- local var1 = Stack:new()
-- var:push(1)
-- var:push(2)
-- print(b.createTable(var))
-- print("var1:"..b.createTable(var1))
-- var:push(3)
-- print(b.createTable(var))
-- var:pop()
-- var:push(4)
-- var:push(3)
-- print(var:isempty())
-- var:pop()
-- var:pop()
-- var:pop()
-- var:pop()


-- print(var:isempty())

--测试不同对象的元表是否会改变

local a,b,c = {},{},{}
local d = {}

setmetatable(a,c)
setmetatable(b,c)
c.__index = d
-- c.__index = d
c.__newindex = d
b.b = "ggggg"
d.x = 1
d.y = 2
c.__add =function (x,y)
    return x.x + y.y
end

print("------")
print(b.b)
print(b.x)

print("------")
print(a.x)
print(a.b)

--私有性的实现（Privacy)
local function newAccount(initialBalance)
    local self = {balance = initialBalance}
    local withdraw = function (v)
        self.balance = self.balance - v
    end
    local deposit = function (v)
        self.balance = self.balance + v
    end

    local getBalance = function ()
        return self.balance
    end

    return {withdraw = withdraw,deposit = deposit,getBalance = getBalance}

end


-- 对偶表示
