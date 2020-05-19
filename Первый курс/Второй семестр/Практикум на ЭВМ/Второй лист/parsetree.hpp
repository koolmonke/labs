#include <cstdio>  //printf
#include <cstdlib> //exit
#include <iostream>
size_t STRING_ITER = 0;

struct Expr {
  char op;
  int data;
  Expr *expr[2];
};

void parse_error(const char *string) {
  printf("Неожиданный символ '%c' на позиции '%lu'.\n", string[STRING_ITER],
         STRING_ITER);
  printf("Ввод: %s\n", string);
  for (size_t i = 0; i < STRING_ITER + 6; i++) {
    std::cout << ' ';
  }
  printf("%c\n", '^');
  exit(1);
}

void print(Expr *expr) {
  if (expr) {
      print(expr->expr[0]);
    if (expr -> op != 'd')
      std::cout << expr->op << '\n';
    if (expr->expr[1])
      print(expr->expr[1]);
    std::cout << expr->data << '\n';
  }
}

char consume_char(const char *string, char c) { //кушает +, -, *,/ , )
  if (string[STRING_ITER] != c) {
    parse_error(string);
  }
  STRING_ITER++;
  return c;
}

int consume_int(const char *string) { //кушает цифры
  int i;
  if (!isdigit(string[STRING_ITER])) {
    parse_error(string);
  }
  i = atoi(string + STRING_ITER); // передаю число в atoi, а не всю строку
  while (isdigit(string[STRING_ITER])) {
    STRING_ITER++;
  }
  return i;
}

Expr *expression(const char *string);

Expr *factor(const char *string, Expr *expr) {
  if (string[STRING_ITER] == '(') {
    expr->op = consume_char(string, '(');
    expr->expr[0] = expression(string);
    consume_char(string, ')');
  } else if (isdigit(string[STRING_ITER])) {
    expr->op = 'd';
    expr->data = consume_int(string);
  }
  return expr;
}

Expr *factor_tail(const char *string, Expr *expr) {
  Expr *new_expr;
  switch (string[STRING_ITER]) {
  case '*':
  case '/':
    if (NULL == (new_expr = new Expr)) {
      exit(1);
    }
    if (NULL == (new_expr->expr[1] = new Expr)) {
      exit(1);
    }
    new_expr->op = consume_char(string, string[STRING_ITER]);
    new_expr->expr[0] = expr;

    new_expr->expr[1] = factor(string, new_expr->expr[1]);
    new_expr = factor_tail(string, new_expr);
    return new_expr;
  case '+':
  case '-':
  case ')':
  case 0:
    return expr;
  default:
    parse_error(string);
  }
}

Expr *term(const char *string, Expr *expr) {
  if (string[STRING_ITER] == '(' || isdigit(string[STRING_ITER])) {
    expr = factor(string, expr);
    expr = factor_tail(string, expr);
    return expr;
  } else {
    parse_error(string);
  }
}

Expr *term_tail(const char *string, Expr *expr) {
  Expr *new_expr;

  switch (string[STRING_ITER]) {
  case '+':

  case '-':
    if (NULL == (new_expr = new Expr)) {
      exit(1);
    }
    if (NULL == (new_expr->expr[1] = new Expr)) {
      exit(1);
    }
    new_expr->op = consume_char(string, string[STRING_ITER]);
    new_expr->expr[0] = expr;

    new_expr->expr[1] = term(string, new_expr->expr[1]);
    new_expr = term_tail(string, new_expr);
    return new_expr;
  case ')':
  case 0:
    return expr;
  default:
    parse_error(string);
  }
}

Expr *expression(const char *string) {
  Expr *expr;
  if (string[STRING_ITER] == '(' || isdigit(string[STRING_ITER])) {
    if ((expr = new Expr) == NULL)
      exit(1);
    expr = term(string, expr);
    expr = term_tail(string, expr);
    return expr;
  } else {
    parse_error(string);
  }
}

int evaluate(Expr *expr) { // запус прохода по дереву
  int ret;
  switch (expr->op) {
  case '(':
    ret = evaluate(expr->expr[0]);
    delete expr->expr[0];
    break;
  case '*':
    ret = evaluate(expr->expr[0]) * evaluate(expr->expr[1]);
    delete expr->expr[0];
    delete expr->expr[1];
    break;
  case '/':
    ret = evaluate(expr->expr[0]) / evaluate(expr->expr[1]);
    delete expr->expr[0];
    delete expr->expr[1];
    break;
  case '+':
    ret = evaluate(expr->expr[0]) + evaluate(expr->expr[1]);
    delete expr->expr[0];
    delete expr->expr[1];
    break;
  case '-':
    ret = evaluate(expr->expr[0]) - evaluate(expr->expr[1]);
    delete expr->expr[0];
    delete expr->expr[1];
    break;
  case 'd':
    ret = expr->data;
    break;
  default:
    exit(1);
  }
  return ret;
}
