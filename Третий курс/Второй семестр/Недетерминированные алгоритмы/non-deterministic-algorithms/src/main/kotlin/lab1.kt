import kotlinx.serialization.Serializable
import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import java.io.File

@Serializable
data class Item(val price: Int, val weight: Int)

typealias Items = List<Item>

fun random(sizeOfBackpack: Int, items: Items) = takeWhileBackpackIsNotFull(sizeOfBackpack, items.shuffled())

fun orderedByPricePerKilo(sizeOfBackpack: Int, items: Items) =
    takeWhileBackpackIsNotFull(sizeOfBackpack, items.sortedByDescending { it.price / it.weight })

fun takeWhileBackpackIsNotFull(sizeOfBackpack: Int, items: Items): Items =
    items.zip(items.runningFold(0) { acc, item -> acc + item.weight }).takeWhile { it.second < sizeOfBackpack }
        .dropLast(1).map { pair -> pair.first }

fun main(args: Array<String>) {
    if (args.size == 2) {
        val filename = args[0]
        val items = Json.decodeFromString<List<Item>>(File(filename).readText())
        val sizeOfBackpack = args[1].toInt()
        println(items)
        println(orderedByPricePerKilo(sizeOfBackpack, items))
        println(random(sizeOfBackpack, items))
    } else {
        println("Первый аргумент путь до файла, второй размер рюкзака")
    }
}