import java.io.File


data class Item(val price: Int, val weight: Int)

typealias Items = List<Item>

fun random(sizeOfBackpack: Int, items: Items) = takeWhileBackpackIsNotFull(sizeOfBackpack, items.shuffled())

fun orderedByPricePerKilo(sizeOfBackpack: Int, items: Items) =
    takeWhileBackpackIsNotFull(sizeOfBackpack, items.sortedByDescending { item -> item.price / item.weight })

fun takeWhileBackpackIsNotFull(sizeOfBackpack: Int, items: Items): Items =
    items.zip(items.runningFold(0) { acc, item -> acc + item.weight }).takeWhile { it.second < sizeOfBackpack }
        .dropLast(1).map { pair -> pair.first }

fun main(args: Array<String>) {
    if (args.size == 2) {
        val filename = args[0]
        val items = File(filename).readLines().map {
            val line = it.split(" ")
            Item(line[0].toInt(), line[1].toInt())
        }
        val sizeOfBackpack = args[1].toInt()
        println(items)
        println(orderedByPricePerKilo(sizeOfBackpack, items))
        println(random(sizeOfBackpack, items))
    } else {
        println("Первый аргумент название, второй размер рюкзака")
    }
}