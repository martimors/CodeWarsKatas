fn capitalize_ascii_word(word: &str) -> String {
    let mut s = word.to_string();
    s.remove(0).to_uppercase().to_string() + &s
}

fn camel_case(str: &str) -> String {
    str.split_whitespace().into_iter().map(|x| capitalize_ascii_word(x)).collect::<Vec<String>>().join("")
}


#[test]
fn sample_test() {
    assert_eq!(camel_case("test case"), "TestCase");
    assert_eq!(camel_case("camel case method"), "CamelCaseMethod");
    assert_eq!(camel_case("say hello "), "SayHello");
    assert_eq!(camel_case(" camel case word"), "CamelCaseWord");
    assert_eq!(camel_case(""), "");
}