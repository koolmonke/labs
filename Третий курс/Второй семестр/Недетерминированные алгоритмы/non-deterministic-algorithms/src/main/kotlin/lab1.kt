import kotlinx.serialization.Serializable
import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import java.io.File

typealias Weight = Int

@Serializable
data class Item(val price: Int, val weight: Weight)

typealias Items = List<Item>

data class Backpack(val sizeOfBackpack: Weight) {
    fun fill(items: Items): Pair<Items, Int> {
        var currentSize = 0
        val currentItems = mutableListOf<Item>()
        for (item in items.sortedByDescending { item -> item.weight / item.price }) {
            if ((currentSize + item.weight) <= sizeOfBackpack) {
                currentItems.add(item)
                currentSize += item.weight
            }
        }
        return Pair(currentItems as List<Item>, currentSize)
    }
}

fun main(args: Array<String>) {
    if (args.size == 2) {
        val filename = args[0]
        val items = Json.decodeFromString<Items>(File(filename).readText())
        val sizeOfBackpack = args[1].toInt()
        val backpack = Backpack(sizeOfBackpack)
        println(items)
        println(backpack.fill(items))
    } else {
        println("Первый аргумент путь до файла, второй размер рюкзака")
    }
}