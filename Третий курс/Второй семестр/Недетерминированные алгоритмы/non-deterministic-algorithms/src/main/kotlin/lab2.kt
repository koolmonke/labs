import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import java.io.File

fun <T> Collection<T>.choice() = this.shuffled().take(1)[0]


typealias Node = String

class Graph(vertexes: Map<Node, List<Node>>) {

    val vertexes: Map<Node, List<Node>> = vertexes.filterValues { it.isNotEmpty() }

    fun filterAssociated(v: Node) =
        Graph(vertexes.filterKeys { it != v }
            .mapValues { connected -> connected.value.filter { it != v } })

    override fun toString() = "Graph(vertexes=$vertexes)"
}

fun Graph.solve(): List<Node> {
    tailrec fun inner(graph: Graph, answer: List<Node>): List<Node> = if (graph.vertexes.isNotEmpty()) {
        val randomVert = graph.vertexes.keys.choice()
        val anotherVert = graph.vertexes[randomVert]!!.choice()
        val betterChoice =
            if (graph.vertexes[randomVert]!!.size >= graph.vertexes[anotherVert]!!.size)
                randomVert
            else
                anotherVert
        inner(graph.filterAssociated(betterChoice), answer + listOf(betterChoice))
    } else answer
    return inner(this, listOf())
}

const val number_of_examples = 2

fun main() {
    for (i in 1..number_of_examples) {
        println(
            Graph(Json.decodeFromString(File("docs/lab2/example$i.json").readText()))
                .also { println(it) }.solve()
        )
    }
}