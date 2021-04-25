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
    fun fill(items: Items) =
        items.sortedByDescending { it.weight / it.price }.fold(listOf<Item>() to 0) { backpack, item ->
            if (backpack.second + item.weight <= sizeOfBackpack)
                backpack.first + item to backpack.second + item.weight
            else
                backpack
        }
}

fun main() {
    val filename = "docs/lab1/example.json"
    val backpack = Backpack(50).also { println(it) }
    val (backpackItems, totalWeight) = backpack.fill(
        Json.decodeFromString<Items>(File(filename).readText()).also { println(it) })
    println("Предметы: $backpackItems, их вес $totalWeight")
}