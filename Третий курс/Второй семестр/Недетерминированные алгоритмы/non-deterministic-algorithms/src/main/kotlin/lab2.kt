import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import java.io.File

fun <T> Collection<T>.choice() = this.shuffled().take(1)[0]


data class Graph(var vertexes: Map<String, List<String>>) {
    fun deleteEdgeless() {
        vertexes = vertexes.filter { it.value.isNotEmpty() }
    }

    fun deleteAssociated(v: String) {
        vertexes = vertexes.mapValues { entry -> entry.value.filter { it != v } }.filterKeys { it != v }
        deleteEdgeless()
    }

}

fun solve(graph: Graph): List<String> {
    val answer = mutableListOf<String>()
    graph.deleteEdgeless()
    while (graph.vertexes.isNotEmpty()) {
        val randomVert = graph.vertexes.keys.choice()
        val anotherVert = graph.vertexes[randomVert]!!.choice()
        val betterChoice =
            if (graph.vertexes[randomVert]!!.size >= graph.vertexes[anotherVert]!!.size)
                randomVert
            else
                anotherVert
        answer.add(betterChoice)
        graph.deleteAssociated(betterChoice)
    }
    return answer.toList()
}

fun main() {
    val graph = Json.decodeFromString<Map<String, List<String>>>(File("docs/lab2/example1.json").readText())
    val graphObj = Graph(graph)
    println(solve(graphObj))
}