local Set = {}
--使用指定的列表创建一个新的集合
Set.Mt = {}
Set.Mt.__add = Set.union
function Set.new(l)
    local set = {}
    setmetatable(set,Set.Mt)
    for _,v in ipairs(l) do set[v] = true end
    return set
end
--union
function Set.union(a,b)
    local res = Set.new{}
    for k in pairs(a) do res[k] = true end
    for k in pairs(b) do res[k] = true end
    return res
end
--intersection
function Set.intersection(a,b)
    local res = Set.new{}
    for k in pairs(a) do
        res[k] = b[k]
    end
    return res
end
--将集合表示为字符串
function Set.tostring(set)
    local l = {} --保存集合中所有元素的列表
    for e in pairs(set) do
        l[#l+1] = tostring(e)
    end
    return "{"..table.concat(l,",").."}"
end
return Set
