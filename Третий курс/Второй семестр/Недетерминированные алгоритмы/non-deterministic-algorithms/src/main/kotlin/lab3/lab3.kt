package lab3

import Graph
import Node
import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import lab2.number_of_examples
import java.io.File

fun solve(graph: Graph): Graph {
    tailrec fun inner(connections: List<Pair<Node, Int?>>, graph: Graph): Graph =
        if (!connections.all { it.second == graph.count() - 1 }) {
            inner(
                graph.vertexes.mapValues { graph.countConnections(it.key) }.toList().sortedBy { it.second }
                    .also { println("Отсоритированный массив $it") },
                graph.filterAssociated(connections.first().also { println("Удаляем $it") }.first)
            )
        } else graph
    return inner(graph.vertexes.mapValues { graph.countConnections(it.key) }.toList(), graph)
}


fun main() {
    for (i in 1..number_of_examples) {
        Graph(Json.decodeFromString(File("docs/lab2/example$i.json").readText()))
            .also { println(it) }.also { println(solve(it)) }
    }
}