import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import java.io.File

fun <T> Collection<T>.choice() = this.shuffled().take(1)[0]


class Graph(vertexes: Map<String, List<String>>) {

    val vertexes: Map<String, List<String>> = vertexes.filter { it.value.isNotEmpty() }

    fun filterAssociated(v: String) =
        Graph(vertexes.mapValues { entry -> entry.value.filter { it != v } }.filterKeys { it != v })
}

fun solve(graph: Graph): List<String> {
    tailrec fun inner(graph: Graph, answer: List<String>): List<String> = if(graph.vertexes.isNotEmpty()) {
        val randomVert = graph.vertexes.keys.choice()
        val anotherVert = graph.vertexes[randomVert]!!.choice()
        val betterChoice =
            if (graph.vertexes[randomVert]!!.size >= graph.vertexes[anotherVert]!!.size)
                randomVert
            else
                anotherVert
        inner(graph.filterAssociated(betterChoice),answer + listOf(betterChoice))
    } else answer
    return inner(graph, listOf())
}

fun main() {
    val graph = Json.decodeFromString<Map<String, List<String>>>(File("docs/lab2/example1.json").readText())
    val graphObj = Graph(graph)
    println(solve(graphObj))
}