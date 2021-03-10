import java.lang.IllegalArgumentException

typealias Node = String

class Graph(vertexes: Map<Node, List<Node>>) {

    val vertexes: Map<Node, List<Node>> = run {
        val d = vertexes.filterValues { it.isNotEmpty() }
        for ((vert, conn) in d) {
            for (conn_vert in conn) {
                if (d[conn_vert]?.contains(vert) != true) {
                    throw IllegalArgumentException()
                }
            }
        }
        d
    }

    fun filterAssociated(v: Node) =
        Graph(vertexes.filterKeys { it != v }
            .mapValues { connected -> connected.value.filter { it != v } })

    override fun toString() = "Graph(vertexes=$vertexes)"

    fun count() = vertexes.count()

    fun countConnections(to: Node) = vertexes[to]?.count()

}

