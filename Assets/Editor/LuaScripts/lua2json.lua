local tab = {
    ["Himi"] = "himigame.com",
    ["testArray"] = 123,
    ["age"] = "23",
}
 
--数据转json
function convert(val)
    local cjson = require "cjson"
    local jsonData = cjson.encode(val)
    return jsonData;
end

print(convert(tab));