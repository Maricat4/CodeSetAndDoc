
-- for循环
-- for i = 1, 10 do
--     -- body
--     -- print(i)
--     io.write(i)
-- end

--while 循环
-- while true do
--     -- body
-- end
A = 5
while A>=1 do
    --body
    A = A - 1
    io.write(A..",")
end
-- repeat 循环
repeat
    A = A + 1
    io.write(A..",")
until A>=10
print("---")

--流程控制
if A==10 then
    -- body
    print("A:"..A)
end

if A==10 then
    -- body
    print("A:"..A-1)
else 
    print("A:"..A+1)
end

--function 函数编写
local AA = {11,9,-5,-6,989,93,201,23}

local function bubbleSort(tmp)
    for i = 1, #tmp do
        for j = 1, #tmp-i do
            if tmp[j]>tmp[j+1] then
                local var = tmp[j]
                tmp[j] = tmp[j+1]
                tmp[j+1] = var
            end
 
        end
    end
end
bubbleSort(AA)
io.write("排序后的AA：")
for i = 1, #AA do
    -- body
    io.write(AA[i]..",")
end

--function 函数
local function BinarySearch(tmpNum,targetNum)
    local i = 1
    local j = #tmpNum
    local tmp = nil
    while i<=j do
        -- body
        tmp = math.ceil((i+j)/2)
        if tmpNum[tmp]==targetNum then
            return tmp,targetNum
        elseif tmpNum[tmp]>targetNum then
            -- body
            j = tmp - 1
        else
            i = tmp + 1
        end
    end
    return tmp,tmpNum[tmp]

end
print(" ")
-- local var1,var2 = BinarySearch(AA,22)
-- print(var1..","..var2)
local var1,var2 = BinarySearch(AA,22)
print(var1..","..var2)

-- 函数可变参数
local function average(...)
    local result = 0
    local arg={...}
    for i,v in ipairs(arg) do
       result = result + v
    end
    print("总共传入 " .. #arg .. " 个数")
    return result/#arg
end

print("平均值为",average(10,5,3,4,5,6))

print(AA[1]==nil)
print(#AA)
AA[9] = 7
print(#AA)