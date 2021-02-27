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

fun random(sizeOfBackpack: Weight, items: Items) = takeWhileBackpackIsNotFull(sizeOfBackpack, items.shuffled())

fun orderedByPricePerKilo(sizeOfBackpack: Weight, items: Items) =
    takeWhileBackpackIsNotFull(sizeOfBackpack, items.sortedByDescending { it.price / it.weight })

fun orderByWeight(sizeOfBackpack: Weight, items: Items) =
    takeWhileBackpackIsNotFull(sizeOfBackpack, items.sortedBy { it.weight })

fun takeWhileBackpackIsNotFull(sizeOfBackpack: Weight, items: Items): Items =
    items.zip(items.runningFold(0) { acc, item -> acc + item.weight }).takeWhile { it.second < sizeOfBackpack }
        .dropLast(1).map(Pair<Item, Int>::first)

fun main(args: Array<String>) {
    if (args.size == 2) {
        val filename = args[0]
        val items = Json.decodeFromString<Items>(File(filename).readText())
        val sizeOfBackpack = args[1].toInt()
        val backpack = Backpack(sizeOfBackpack)
        println(backpack.fill(items))
        println(items)
    } else {
        println("Первый аргумент путь до файла, второй размер рюкзака")
    }
}