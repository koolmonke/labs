package lab3

import Graph
import Node
import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import lab2.number_of_examples
import java.io.File

fun solve(graph: Graph): Graph {
    tailrec fun inner(connections: Map<Node, Int?>, graph: Graph): Graph =
        if (connections.any { it.value != graph.vertexes.count() - 1 }) {
            inner(
                graph.vertexes.mapValues { graph.countConnections(it.key) },
                graph.filterAssociated(connections.minOfWith(compareBy { it.value }) { it }.key)
            )
        } else graph
    val connections = graph.vertexes.mapValues { graph.countConnections(it.key) }
    return inner(connections, graph.filterAssociated(connections.minOfWith(compareBy { it.value }) { it }.key))
}


fun main() {
    for (i in 1..number_of_examples) {
        Graph(Json.decodeFromString(File("docs/lab2/example$i.json").readText()))
            .also { println(it) }.also { println(solve(it)) }
    }
}