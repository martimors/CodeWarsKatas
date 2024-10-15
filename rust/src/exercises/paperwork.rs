fn paperwork(n: i16, m: i16) -> u32 {
    (n.max(0) as u32) * (m.max(0) as u32)
}

#[cfg(test)]
mod tests {
    use super::paperwork;

    fn dotest(n: i16, m: i16, expected: u32) {
        let actual = paperwork(n, m);
        assert!(
            actual == expected,
            "With n = {n}, m = {m}\nExpected {expected} but got {actual}"
        )
    }

    #[test]
    fn test_paperwork() {
        dotest(5, 5, 25);
        dotest(5, -5, 0);
        dotest(-5, -5, 0);
        dotest(-5, 5, 0);
        dotest(5, 0, 0);
    }
}
