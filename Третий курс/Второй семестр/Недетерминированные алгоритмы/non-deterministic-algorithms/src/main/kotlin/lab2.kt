import kotlinx.serialization.Serializable
import kotlinx.serialization.decodeFromString
import kotlinx.serialization.json.Json
import java.io.File

// cover using Binary Search
class GFG(private val maxN: Int) {

    // Global array to store the graph
    // Note: since the array is global, all the 
    // elements are 0 initially 
    private val gr = Array(maxN) { BooleanArray(maxN) }
    var edgeCount = 0
        private set

    var vertexCount = 0
        private set
        get() = gr.count { line -> line.any { it } }

    override fun toString(): String {
        var acc = ""
        for (booleans in gr) {
            for (item in booleans) {
                acc += "${if (item) 1 else 0} "
            }
            acc += "\n"
        }
        return acc
    }

    // Returns true if there is a possible subset
    // of size 'k' that can be a vertex cover
    private fun isCover(V: Int, k: Int, E: Int): Boolean {
        // Set has first 'k' bits high initially
        var set = (1 shl k) - 1
        val limit = 1 shl V

        // to mark the edges covered in each subset
        // of size 'k'
        val vis = Array(maxN) { BooleanArray(maxN) }
        while (set < limit) {
            // Reset visited array for every subset
            // of vertices
            for (i in 0 until maxN) {
                for (j in 0 until maxN) {
                    vis[i][j] = false
                }
            }
            // set counter for number of edges covered
            // from this subset of vertices to zero
            var cnt = 0

            // selected vertex cover is the indices
            // where 'set' has its bit high
            var j = 1
            var v = 1
            while (j < limit) {
                if (set and j != 0) {
                    // Mark all edges emerging out of this
                    // vertex visited
                    for (co in 1..V) {
                        if (gr[v][co] && !vis[v][co]) {
                            vis[v][co] = true
                            vis[co][v] = true
                            cnt++
                        }
                    }
                }
                j = j shl 1
                v++
            }

            // If the current subset covers all the edges
            if (cnt == E) return true

            // Generate previous combination with k bits high
            // set & -set = (1 << last bit high in set)
            val co = set and -set
            val ro = set + co
            set = (ro xor set shr 2) / co or ro
        }
        return false
    }

    // Returns answer to graph stored in gr[][]
    fun findMinCover(n: Int = vertexCount, m: Int = edgeCount): Int {
        // Binary search the answer
        var left = 1
        var right = n
        while (right > left) {
            val mid = left + right shr 1
            if (!isCover(n, mid, m)) left = mid + 1 else right = mid
        }

        // at the end of while loop both left and
        // right will be equal,/ as when they are
        // not, the while loop won't exit the minimum
        // size vertex cover = left = right
        return left
    }

    // Inserts an edge in the graph
    fun insertEdge(u: Int, v: Int) {
        if (!gr[u][v])
            edgeCount++
        gr[u][v] = true
        gr[v][u] = true // Undirected graph
    }

}

@Serializable
data class Edge(val u: Int, val v: Int)

fun main() {
    /*
     6
     |
     1 --- 5 vertex cover = {1, 2}
    /|\
   3 | \
   \ /  \
    2    4 */
    GFG(7).run {
        for (edge in Json.decodeFromString<List<Edge>>(File("docs/lab2/example1.json").readText())) {
            insertEdge(edge.u, edge.v)
        }

        print(this)
        println("vertexCount = $vertexCount and edgeCount = $edgeCount")
        println("Minimum size of a vertex cover = ${findMinCover()}")
        println()
    }


    /*
     2----4----6
    /|    |
   1 |    | vertex cover = {2, 3, 4}
    \|    |
     3----5 */
    GFG(7).run {
        for (edge in Json.decodeFromString<List<Edge>>(File("docs/lab2/example2.json").readText())) {
            insertEdge(edge.u, edge.v)
        }

        print(this)
        println("vertexCount = $vertexCount and edgeCount = $edgeCount")
        println("Minimum size of a vertex cover = ${findMinCover()}")
    }
}
