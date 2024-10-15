fn sum_of_weight(w: &str) -> u32 {
    w.chars().map(
        |wc|
            wc.to_digit(10).unwrap_or(0)
    ).sum()
}


fn order_weight(s: &str) -> String {
    let mut weights = s.split_whitespace()
        .into_iter().map(
        |w| (sum_of_weight(w), w)
    ).collect::<Vec<(u32, &str)>>();
    weights.sort();
    weights.into_iter().map(|(_, x)| x).collect::<Vec<&str>>().join(" ")
}


fn testing(s: &str, exp: &str) -> () {
    assert_eq!(order_weight(s), exp)
}

#[test]
fn basics_order_weight() {
    testing("103 123 4444 99 2000", "2000 103 123 4444 99");
    testing("2000 10003 1234000 44444444 9999 11 11 22 123",
            "11 11 2000 10003 22 123 1234000 44444444 9999");
}
