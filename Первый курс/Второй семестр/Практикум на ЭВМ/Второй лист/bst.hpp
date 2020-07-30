#include <iostream>
class BST {
  struct node {
    int data;
    node *left;
    node *right;
  };

  node *root;

  node *makeEmpty(node *t) {
    if (t == NULL)
      return NULL;
    {
      makeEmpty(t->left);
      makeEmpty(t->right);
      delete t;
    }
    return NULL;
  }
  node *newNode(int key) {
    node *newNode = new node;
    newNode->data = key;
    newNode->left = newNode->right = NULL;
    return newNode;
  }
  void insert(node *&root, int key) {
    // if the root is null, create a new node an return it
    if (root == NULL) {
      root = newNode(key);
      return;
    }

    // if given key is less than the root node, recurse for left subtree
    // else recurse for right subtree
    if (key < root->data)
      insert(root->left, key);
    else // key >= root->data
      insert(root->right, key);
  }

  int mintreeDepth(node *t) {
    if ((t->right == NULL) && (t->left == NULL))
      return 0;
    if (t->left == NULL)
      return mintreeDepth(t->right) + 1;
    else if (t->right == NULL)
      return mintreeDepth(t->left) + 1;
    return std::min(mintreeDepth(t->left), mintreeDepth(t->right)) + 1;
  }
  void PrintTree(node *t, int space) {
    if (t) {
      PrintTree(t->left, space + 5);
      for (int i = 0; i < space; i++)
        std::cout << ' ';
      std::cout << t->data << '\n';
      PrintTree(t->right, space + 5);
    }
  }

  node *findMin(node *t) {
    if (t == NULL)
      return NULL;
    else if (t->left == NULL)
      return t;
    else
      return findMin(t->left);
  }

  node *findMax(node *t) {
    if (t == NULL)
      return NULL;
    else if (t->right == NULL)
      return t;
    else
      return findMax(t->right);
  }
  int maxvalue(node *t) {
    if (t == NULL)
      return -1;
    int rootval = t->data;
    int leftval = maxvalue(t->left);
    int rightval = maxvalue(t->right);
    if (leftval > rootval)
      rootval = leftval;
    if (rightval > rootval)
      rootval = rightval;
    return rootval;
  }

  node *remove(int x, node *t) {
    node *temp;
    if (t == NULL)
      return NULL;
    else if (x < t->data)
      t->left = remove(x, t->left);
    else if (x > t->data)
      t->right = remove(x, t->right);
    else if (t->left && t->right) {
      temp = findMin(t->right);
      t->data = temp->data;
      t->right = remove(t->data, t->right);
    } else {
      temp = t;
      if (t->left == NULL)
        t = t->right;
      else if (t->right == NULL)
        t = t->left;
      delete temp;
    }

    return t;
  }

  void inorder(node *t) {
    if (t == NULL)
      return;
    inorder(t->left);
    std::cout << t->data << " ";
    inorder(t->right);
  }

  node *find(node *t, int x) {
    if (t == NULL)
      return NULL;
    else if (x < t->data)
      return find(t->left, x);
    else if (x > t->data)
      return find(t->right, x);
    else
      return t;
  }

public:
  BST() { root = NULL; }
  int mintreelen() { return mintreeDepth(root); };
  ~BST() { root = makeEmpty(root); }
  void insert(int x) { insert(root, x); }
  int max() { return findMax(root)->data; }
  void newPrint() { PrintTree(root, 0); }
  void remove(int x) { root = remove(x, root); }
  void display() {
    inorder(root);
    std::cout << std::endl;
  }

  void search(int x) { root = find(root, x); }
};
