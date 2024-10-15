fn narcissistic(num: u64) -> bool {
    let num_string = num.to_string();
    num.to_string()
        .chars()
        .map(|d| d.to_digit(10).unwrap() as u64)
        .map(|d| d.pow((num_string.len()) as u32))
        .sum::<u64>() == num
}


#[cfg(test)]
mod tests {
    use super::*;

    fn dotest(input: u64, expected: bool) {
        let actual = narcissistic(input);
        assert_eq!(actual, expected, "\nIncorrect answer for n={}\nExpected: {expected}\nActual: {actual}", input)
    }

    #[test]
    fn basic_tests() {
        dotest(7, true);
        dotest(371, true);
        dotest(122, false);
        dotest(4887, false);
        dotest(32164049651, true);
    }
}