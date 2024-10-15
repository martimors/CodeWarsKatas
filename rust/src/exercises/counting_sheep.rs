fn count_sheep(sheep: &[bool]) -> u8 {
    sheep.iter().map(|&n| n as u8).sum()
}

#[test]
fn returns_correct_sheep_count() {
    assert_eq!(count_sheep(&[false]), 0);
    assert_eq!(count_sheep(&[true]), 1);
    assert_eq!(count_sheep(&[true, false]), 1);
}
