--定义一个module
local mathtool = {}

mathtool.path = "文件路径"

function mathtool.createTable(...)
    -- body
    local tmp = ...
    return table.concat(tmp,",",1,#tmp)
end

local function fun2()
    -- body
    print("私有函数")
end

function mathtool:func3()
    -- body
    AA = {1,2,3,4,5,6}
    fun2()
end

return mathtool

