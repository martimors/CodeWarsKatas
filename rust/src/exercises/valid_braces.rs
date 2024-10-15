fn is_closing(c: char) -> bool {
    String::from(")}]").find(c).is_some()
}


fn matching_braces(opens: char, closes: char) -> bool {
    match opens {
        '(' => closes == ')',
        '[' => closes == ']',
        '{' => closes == '}',
        _ => panic!()
    }
}

fn valid_braces(s: &str) -> bool {
    if !(s.len() % 2 == 0) {
        return false;
    }
    let mut s_str = s.to_string();
    let mut seq = vec![s_str.remove(0)];

    for c in s_str.chars() {
        if is_closing(c) {
            // TODO: Instead of the empty checking, just pop and pattern match
            if seq.is_empty() {
                return false;
            }
            if matching_braces(seq.last().unwrap().to_owned(), c) {
                seq.pop();
                continue;
            }
            return false;
        }
        seq.push(c);
    }

    seq.len() == 0
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn basic_tests() {
        expect_true("()");
        expect_false("[(])");
        expect_true("[({})]");
        expect_true("()[]{}");
        expect_false("[(])");
        expect_true("([{}])");
        expect_false(")(}{][");
        expect_true("({})[({})]");
    }

    #[test]
    fn weird_test() {
        expect_false("())({}}{()][][");
    }

    fn expect_true(s: &str) {
        assert!(valid_braces(s), "Expected {s:?} to be valid. Got false", s = s);
    }

    fn expect_false(s: &str) {
        assert!(!valid_braces(s), "Expected {s:?} to be invalid. Got true", s = s);
    }
}