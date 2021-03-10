package lab1

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
        for (item in items.sortedByDescending { it.weight / it.price }) {
            if ((currentSize + item.weight) <= sizeOfBackpack) {
                currentItems.add(item)
                currentSize += item.weight
            }
        }
        return Pair(currentItems as List<Item>, currentSize)
    }
}

fun main() {
    val filename = "docs/lab1/example.json"
    val backpack = Backpack(50).also { println(it) }
    val (optimalItemsInBackpack, optimalSize) = backpack.fill(
        Json.decodeFromString<Items>(File(filename).readText()).also { println(it) })
    println("Предметы: $optimalItemsInBackpack, их вес $optimalSize")
}