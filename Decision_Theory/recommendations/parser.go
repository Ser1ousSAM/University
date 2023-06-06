package main

import (
	"encoding/csv"
	"fmt"
	"log"
	"os"
	"strconv"
)

type Film struct {
	Name     string
	Year     int
	Rating   float64
	Duration int
}

// relevance coefficients
const (
	ratingRelevance   = 1.5
	durationRelevance = 2
	yearRelevance     = 0.5
)

func createFilmList(data [][]string) []Film {
	var filmsList []Film
	for i, line := range data {
		if i > 0 { // omit header line
			var f Film
			for j, field := range line {
				if j == 0 {
					f.Name = field
				} else if j == 1 {
					year, err := strconv.Atoi(field)
					if err != nil {
						panic(err)
					}
					f.Year = year
				} else if j == 2 {
					rating, err := strconv.ParseFloat(field, 64)
					if err != nil {
						panic(err)
					}
					f.Rating = rating
				} else if j == 3 {
					duration, err := strconv.Atoi(field)
					if err != nil {
						panic(err)
					}
					f.Duration = duration
				}
			}
			filmsList = append(filmsList, f)
		}
	}
	return filmsList
}

// 1)
func pareto(filmList []Film) []Film {
	var paretoSet []Film
	best := true
	paretoSet = append(paretoSet, filmList[0])
	for i := 1; i < len(filmList); i++ {

		for _, paretoFilm := range filmList {
			best = true
			if paretoFilm.Rating < filmList[i].Rating &&
				paretoFilm.Duration > filmList[i].Duration &&
				paretoFilm.Year < filmList[i].Year {
				best = false
			}
		}
		if best {
			paretoSet = append(paretoSet, filmList[i])
		}
	}
	return paretoSet
}

const (
	maxDuration = 130
	minYear     = 1995
	minRating   = 7.0
)

// 2)
func lowerBounds(filmList []Film) []Film {
	var lowerBoundsList []Film
	for _, film := range filmList {
		if film.Duration < maxDuration && film.Year > minYear && film.Rating > minRating {
			lowerBoundsList = append(lowerBoundsList, film)
		}
	}
	return lowerBoundsList
}

// 3)
func subOptimisation(filmList []Film) []Film {
	var subOptList []Film
	var best float64 = 0
	for _, film := range filmList {
		if film.Year > minYear && film.Rating > minRating && float64(film.Duration) < best {
			best = float64(film.Duration)
		}
	}
	for _, film := range filmList {
		if float64(film.Year) == best {
			subOptList = append(subOptList, film)
		}
	}
	return subOptList
}

// 4)
func lexicographicOptimization(filmList []Film) []Film {
	var lexicoFilms []Film
	var best float64 = 0
	for _, film := range filmList {
		if float64(film.Duration) > best {
			best = float64(film.Duration)
		}
	}
	for _, film := range filmList {
		if float64(film.Duration) == best {
			lexicoFilms = append(lexicoFilms, film)
		}
	}
	if len(lexicoFilms) > 1 {
		filmList = lexicoFilms
		lexicoFilms = lexicoFilms[:0]
		best = 0
		for _, film := range filmList {
			if float64(film.Year) > best {
				best = float64(film.Year)
			}
		}
		for _, film := range filmList {
			if float64(film.Year) == best {
				lexicoFilms = append(lexicoFilms, film)
			}
		}
	}

	if len(lexicoFilms) > 1 {
		filmList = lexicoFilms
		lexicoFilms = lexicoFilms[:0]
		best = 0
		for _, film := range filmList {
			if film.Rating > best {
				best = film.Rating
			}
		}
		for _, film := range filmList {
			if film.Rating == best {
				lexicoFilms = append(lexicoFilms, film)
			}
		}
	}
	return filmList
}

// 5)
func generalizedCriterion(filmList []Film) []Film {
	var generalizedFilms []Film
	var best float64 = 0
	var minDuration float64 = 0
	for _, film := range filmList {
		if minDuration > float64(film.Duration) {
			minDuration = float64(film.Duration)
		}
	}

	for _, film := range filmList {
		if float64(film.Duration)/minDuration*float64(durationRelevance)+
			float64(film.Year)*yearRelevance+
			film.Rating*ratingRelevance > best {
			best = float64(film.Duration)/minDuration*float64(durationRelevance) +
				float64(film.Year)*yearRelevance +
				film.Rating*ratingRelevance
		}

	}
	for _, film := range filmList {
		if float64(film.Duration)/minDuration*float64(durationRelevance)+
			float64(film.Year)*yearRelevance+
			film.Rating*ratingRelevance == best {
			generalizedFilms = append(generalizedFilms, film)
		}
	}
	return generalizedFilms
}

func printFilms(filmsList []Film) {
	for _, film := range filmsList {
		fmt.Println(film.Name, " ", film.Duration, " minutes ", film.Rating, " stars ", film.Year, " year")
	}
}

func parseCsv(csvTitle string) [][]string {
	// open file
	f, err := os.Open(csvTitle)
	if err != nil {
		log.Fatal(err)
	}

	// read csv values using csv.Reader
	csvReader := csv.NewReader(f)
	data, err := csvReader.ReadAll()
	if err != nil {
		log.Fatal(err)
	}
	defer func(f *os.File) {
		err := f.Close()
		if err != nil {
			print("csv reading error")
		}
	}(f)
	return data
}

/*
as min as possible duration
as max as possible rating
as max as possible year
*/
func main() {
	data := parseCsv("dataSets/merged.csv")
	filmsList := createFilmList(data)

	fmt.Println("Put one of the following args throw the space and after the most valuable attribute:")
	fmt.Println("(pareto, lower, sub, lexical, general)")
	var filmSet []Film
	if len(os.Args) < 2 {
		fmt.Println("You didn't enter any args")
	} else {
		switch arg := os.Args[1]; arg {
		case "pareto", "1":
			filmSet = pareto(filmsList)
			fmt.Println("pareto:")
		case "lower", "2":
			filmSet = lowerBounds(filmsList)
			fmt.Println("lowerBounds:")
		case "sub", "3":
			filmSet = subOptimisation(filmsList)
			fmt.Println("subOptimisation:")
		case "lexical", "4":
			filmSet = lexicographicOptimization(filmsList)
			fmt.Println("lexico:")
		case "general", "5":
			filmSet = generalizedCriterion(filmsList)
			fmt.Println("generalized:")
		default:
			fmt.Println("no expacted agrs:" +
				"pareto, lower, sub, lexical, general")
			return
		}
		printFilms(filmSet)
	}
}
