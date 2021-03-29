package lab1

import kotlinx.serialization.Serializable
import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import java.io.File

typealias Weight = Int

@Serializable
data class Item(val price: Int, val weight: Weight)

typealias Items = List<Item>

fun Items.currentSize() = this.map { it.weight }.sum()

data class Backpack(val sizeOfBackpack: Weight) {
    fun fill(items: Items): Items = items.sortedByDescending { it.weight / it.price }.fold(listOf()) { backpack, item ->
        if (backpack.currentSize() + item.weight <= sizeOfBackpack)
            backpack + item
        else
            backpack
    }
}

fun main() {
    val filename = "docs/lab1/example.json"
    val backpack = Backpack(50).also { println(it) }
    val backpackItems = backpack.fill(
        Json.decodeFromString<Items>(File(filename).readText()).also { println(it) })
    println("Предметы: $backpackItems, их вес ${backpackItems.currentSize()}")
}