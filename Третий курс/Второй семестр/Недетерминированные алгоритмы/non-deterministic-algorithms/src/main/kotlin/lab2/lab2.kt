package lab2

import Graph
import Node
import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import java.io.File

fun <T> Iterable<T>.choice() = this.shuffled().take(1)[0]


fun solve(graph: Graph): List<Node> {
    tailrec fun inner(graph: Graph, answer: List<Node>): List<Node> = if (graph.vertexes.isNotEmpty()) {
        val randomVert = graph.vertexes.keys.choice()
        val anotherVert = graph.vertexes[randomVert]!!.choice()
        val betterChoice =
            if (graph.vertexes[randomVert]!!.size >= graph.vertexes[anotherVert]!!.size)
                randomVert
            else
                anotherVert
        inner(graph.filterAssociated(betterChoice), answer + betterChoice)
    } else answer
    return inner(graph, listOf())
}

const val number_of_examples = 2

fun main() {
    for (i in 1..number_of_examples) {
            Graph(Json.decodeFromString(File("docs/lab2/example$i.json").readText()))
                .also { println(it) }.also { println(solve(it)) }
    }
}