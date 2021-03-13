import java.lang.IllegalArgumentException

typealias Node = String

class Graph(vertexes: Map<Node, List<Node>>) {

    val vertexes: Map<Node, List<Node>> = run {
        val map = vertexes.filterValues { it.isNotEmpty() }
        for ((vertex, connected) in map) {
            for (connectedVertex in connected) {
                if (map[connectedVertex]?.contains(vertex) != true) {
                    throw IllegalArgumentException()
                }
            }
        }
        map
    }

    fun filterAssociated(v: Node) =
        Graph(vertexes.filterKeys { it != v }
            .mapValues { connected -> connected.value.filter { it != v } })

    override fun toString() = "Graph(vertexes=$vertexes)"

    fun countConnections(to: Node) = vertexes[to]?.count()

}

