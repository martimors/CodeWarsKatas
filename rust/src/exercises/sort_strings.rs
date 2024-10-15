fn find_number(string_n: &str) -> i32 {
    // Finds the first number in a string and returns it as an i32
    string_n.chars().filter(|c| c.is_digit(10)).collect::<String>().parse::<i32>().unwrap()
}

fn order(sentence: &str) -> String {
    let mut splut = sentence.split_whitespace().into_iter().map(|word| (find_number(word), word)).collect::<Vec<(i32, &str)>>();
    splut.sort();
    // code here

    splut.into_iter().map(|(_, word)| word).collect::<Vec<&str>>().join(" ")
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn find_number_finds_number() {
        assert_eq!(find_number("is2"), 2);
        assert_eq!(find_number("Thi1s"), 1);
        assert_eq!(find_number("T4est"), 4);
        assert_eq!(find_number("3a"), 3);
    }

    #[test]
    fn returns_expected() {
        assert_eq!(order("is2 Thi1s T4est 3a"), "Thi1s is2 3a T4est");
        assert_eq!(order(""), "");
    }
}
