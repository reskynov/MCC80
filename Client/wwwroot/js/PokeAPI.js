// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const cardColors = {
    normal: '#A8A77A',
    fire: '#EE8130',
    water: '#6390F0',
    electric: '#F7D02C',
    grass: '#7AC74C',
    ice: '#96D9D6',
    fighting: '#C22E28',
    poison: '#A33EA1',
    ground: '#E2BF65',
    flying: '#A98FF3',
    psychic: '#F95587',
    bug: '#A6B91A',
    rock: '#B6A136',
    ghost: '#735797',
    dragon: '#6F35FC',
    dark: '#705746',
    steel: '#B7B7CE',
    fairy: '#D685AD'
}
//saved data pokemon
const allPokemons = [];

$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon?limit=100&offset=0",
    async : false
}).done((resultAll) => {
    
    let tempPoke = "";
    let column = 0;
    let item = 0;
    tempPoke += `<div class="row">`;
    //setiap pokemon data
    $.each(resultAll.results, (index, val) => {
        let pokemonDetail = getPokemonDetail(val.url)
        allPokemons.push(pokemonDetail);
        tempPoke += `<div id=${item} class="col-poke col border border-2 rounded m-4 d-flex flex-column align-items-center justify-content-center"
                          style="height : 230px; cursor: pointer; background-color: ${backgroundColor(pokemonDetail)}"
                           data-bs-toggle="modal" data-bs-target="#pokemonModal">
                          <img src="${pokemonDetail.sprites.other['official-artwork'].front_default}" alt="pokemon-potrait" class="img-fluid pokemon-potrait">
                          <div class="pokemon-name">${val.name.charAt(0).toUpperCase() + val.name.slice(1)}</div>
                     </div>`;
        column++;
        item++;
        if (column % 3 === 0) {
            tempPoke += '</div><div class="row">';
            column = 0;
        }
    });
    tempPoke += '</div>';
    $("#pokemon").html(tempPoke);
});

function getPokemonDetail(pokemonUrl) {
    let resultAPI;
    $.ajax({
        url: pokemonUrl,
        async: false
    }).done((result) => {
        resultAPI = result;
    });
    return resultAPI;
}

function backgroundColor(pokemonDetail) {
    for (let type in cardColors) {
        if (type === pokemonDetail.types[0].type.name) {
            return cardColors[type];
        }
    }
}

function backgroundColorType(pokemonTypes) {
    for (let type in cardColors) {
        if (type === pokemonTypes.type.name) {
            return cardColors[type];
        }
    }
}

//modal open
$(document).ready(function () {
    $(".col-poke").each(function (index) {
        $(this).on("click", function () {
            //background color
            $(".modal-content").css("background-color", `${backgroundColor(allPokemons[index])}`);

            //pokemon name
            $(".modal-title").html(allPokemons[index].name.charAt(0).toUpperCase() + allPokemons[index].name.slice(1));

            //pokemon type
            let types = "";
            (allPokemons[index].types).forEach((value) => {
                types += `<span class="badge badge-primary border border-white ms-1" style="background-color:${backgroundColorType(value)};">${value.type.name.charAt(0).toUpperCase() + value.type.name.slice(1)}</span>`;
            });
            $(".modal-badge").html(types);

            //pokemon pic
            $(".modal-pokemon-potrait").attr("src", `${allPokemons[index].sprites.other['official-artwork'].front_default}`);

            //pokemon data
            //height
            let pokemonHeight = `<th>Height</th>
                                 <td>${(allPokemons[index].height) * 10} Cm</td>`;
            $(".pokemon-height").html(pokemonHeight)

            //weight
            let pokemonWeight = `<th>Weight</th>
                                 <td>${(allPokemons[index].weight) / 10} Kg</td>`;
            $(".pokemon-weight").html(pokemonWeight)

            //abilities
            let abilities = `<th>Abilities</th>`;
            (allPokemons[index].abilities).forEach((value) => {
                abilities += `<td>${value.ability.name.charAt(0).toUpperCase() + value.ability.name.slice(1) }</td>`;
            });
            $(".pokemon-abilities").html(abilities)

            //pokemon stats
            let barHp = ((allPokemons[index].stats[0].base_stat)/255)*100;

            let statsPokemon = "";
            (allPokemons[index].stats).forEach((stats) => {
                //nama stat
                let statName = stats.stat.name;
                statName = statName.replace('-', ' ');
                statName = statName.charAt(0).toUpperCase() + statName.slice(1);

                //value stat
                let statValue = parseInt(((stats.base_stat)/255)*100);

                statsPokemon += `<tr>
                                    <th>
                                        ${statName}
                                        <div class="progress position-relative">
                                            <div class="progress-bar ${stats.stat.name}" style="width: ${statValue}%;" role="progressbar" aria-valuenow="${statValue}" aria-valuemin="0" aria-valuemax="100"></div>
                                            <small class="justify-content-center d-flex position-absolute w-100">${statValue}</small>
                                         </div>
                                    </th>
                                </tr>`
            });
            $(".tbody-stat").html(statsPokemon)
            


        });
    });
});