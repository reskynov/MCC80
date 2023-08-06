//array of object
const animals = [
    { name: "dory", species: "fish", class: { name: "vertebrata" } },
    { name: "tom", species: "cat", class: { name: "mamalia" } },
    { name: "nemo", species: "fish", class: { name: "vertebrata" } },
    { name: "umar", species: "cat", class: { name: "mamalia" } },
    { name: "gary", species: "fish", class: { name: "human" } },
]

//bikin sebuah looping ke animals, 2 fungsi :
//fungsi 1: jika species nya 'cat' maka ambil lalu pindahkan ke variabel OnlyCat
const onlyCat = animals.filter((value) => {
    return value.species === "cat";
})

//fungsi 2: jika species nya 'fish' maka ganti class -> menjadi 'non-mamalia'
animals.forEach((value) => {
    if (value.species === "fish") {
        value["class"]["name"] = "non-mamalia";
    }
})

console.log(onlyCat)
console.log(animals)