package main

import (
	"encoding/csv"
	"fmt"
	"log"
	"math"
	"os"
	"sort"
	"strconv"
)

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

func createExpertsList(data [][]string) [][]int {
	expertsList := make([][]int, len(data)-1)
	for i := 0; i < len(expertsList); i++ {
		expertsList[i] = make([]int, len(data[0])-1)
	}
	for i := 0; i < len(expertsList); i++ {
		for j := 0; j < len(expertsList[0]); j++ {
			value, err := strconv.Atoi(data[i+1][j+1])
			if err != nil {
				fmt.Println("Error during conversion")
			}
			expertsList[i][j] = value
		}
	}
	return expertsList
}

func createWeightsList(data [][]string) []float64 {
	var weightsList []float64
	for i := 1; i < len(data); i++ {
		//index 1 means value of weight on each line
		value, err := strconv.ParseFloat(data[i][1], 64)
		if err != nil {
			fmt.Println("Error during conversion")
		}
		weightsList = append(weightsList, value)
	}
	return weightsList
}

func printExpertsConclusion(answer []string) {
	for i, candidate := range answer {
		fmt.Println(i+1, ":", candidate, " ")
	}
}

func ranking(rankingValues []float64, data [][]string) []string {
	var answer []string

	var rankMap map[string]float64
	rankMap = make(map[string]float64)
	for j := 0; j < len(rankingValues); j++ {
		rankMap[data[j+1][0]] = rankingValues[j]
	}

	keys := make([]string, 0, len(rankMap))

	for key := range rankMap {
		keys = append(keys, key)
	}
	sort.SliceStable(keys, func(i, j int) bool {
		return rankMap[keys[i]] < rankMap[keys[j]]
	})

	//'i' can be updated below to len(expertsList[0])
	for i, k := range keys {
		if i > 2 {
			break
		}
		answer = append(answer, k)
	}

	return answer
}

func ranksSumInt(sumRanks *[]int, expertsList [][]int) {
	for j := range expertsList[0] {
		var tempSum int = 0
		for i := range expertsList {
			tempSum += expertsList[i][j]
		}
		*sumRanks = append(*sumRanks, tempSum)
	}
}

func ranksSumFloat(sumRanks *[]float64, expertslistFloat [][]float64) {
	for j := range expertslistFloat[0] {
		var tempSum float64 = 0.0
		for i := range expertslistFloat {
			tempSum += expertslistFloat[i][j]
		}
		*sumRanks = append(*sumRanks, tempSum)
	}
}

// Methods:
// 1)avg_arithmetic_ranks
func avgArithmeticRanks(expertsList [][]int, data [][]string) []string {
	var sumRanks []int
	ranksSumInt(&sumRanks, expertsList)
	var avgRank []float64

	var divisor float64 = float64(len(expertsList))
	for _, value := range sumRanks {
		avgRank = append(avgRank, float64(value)/divisor)
	}

	return ranking(avgRank, data)
}

func medianRank(medians *[]float64, expertsList [][]int) {
	for j := range expertsList[0] {
		var columnValues []int
		for i := range expertsList {
			columnValues = append(columnValues, expertsList[i][j])
		}
		sort.SliceStable(columnValues, func(i, j int) bool {
			return columnValues[i] < columnValues[j]
		})
		var middleValue int = len(columnValues) / 2
		if len(columnValues)%2 == 1 {
			*medians = append(*medians, float64(columnValues[middleValue]))
		} else {
			var temp float64 = (float64(columnValues[middleValue-1]) + float64(columnValues[middleValue])) / 2
			*medians = append(*medians, temp)
		}
	}
}

// 2)median_ranks
func medianRanks(expertsList [][]int, data [][]string) []string {
	var medians []float64
	medianRank(&medians, expertsList)

	return ranking(medians, data)
}

// 3)degree_assessment_consistency
func degreeAssessmentConsistency(expertsList [][]int) float64 {
	var sumRanks []int
	ranksSumInt(&sumRanks, expertsList)

	var avgRankSumm float64 = 0
	for i := range sumRanks {
		avgRankSumm += float64(sumRanks[i])
	}
	avgRankSumm /= float64(len(expertsList[0]))

	var diffMidAvgs []float64
	var doubleDiffMidAvgs []float64
	var sumDoubleDiffMidAvgs float64 = 0.0

	for i := 0; i < len(sumRanks); i++ {
		diffMidAvgs = append(diffMidAvgs, avgRankSumm-float64(sumRanks[i]))
		doubleDiffMidAvgs = append(doubleDiffMidAvgs, diffMidAvgs[i]*diffMidAvgs[i])
		sumDoubleDiffMidAvgs += doubleDiffMidAvgs[i]
	}

	var m float64 = float64(len(expertsList))
	var n float64 = float64(len(expertsList[0]))

	var concordanceCoeff float64 = (12 * sumDoubleDiffMidAvgs) / (math.Pow(m, 2) * (math.Pow(n, 3) - n))

	return concordanceCoeff
}

// 4)weight_coefficients
func weightsCoefficients(expertsList [][]int, data [][]string) []string {
	floatExpertslist := make([][]float64, len(expertsList))
	for i := range floatExpertslist {
		floatExpertslist[i] = make([]float64, len(expertsList[i]))
	}
	weights := createWeightsList(data)
	for j := range floatExpertslist[0] {
		for i := range floatExpertslist {
			floatExpertslist[i][j] = weights[i] * float64(expertsList[i][j])
		}
	}

	var sumRanksFloat []float64
	ranksSumFloat(&sumRanksFloat, floatExpertslist)
	var avgRanks []float64

	var divider float64 = float64(len(floatExpertslist))
	for _, value := range sumRanksFloat {
		avgRanks = append(avgRanks, value/divider)
	}

	return ranking(avgRanks, data)
}

func main() {
	tableData := parseCsv("qwe/table.csv")
	// convert records to array of structs
	dataAssignments := createExpertsList(tableData)
	fmt.Println("1) avg_arithmetic_ranks:")
	printExpertsConclusion(avgArithmeticRanks(dataAssignments, tableData))

	fmt.Println("2) median_ranks:")
	printExpertsConclusion(medianRanks(dataAssignments, tableData))

	consistency := fmt.Sprintf("%.4f", degreeAssessmentConsistency(dataAssignments))
	fmt.Println("3) degree_assessment_consistency:", consistency)

	weightsData := parseCsv("weights.csv")
	fmt.Println("4) weights_coefficients:")
	printExpertsConclusion(weightsCoefficients(dataAssignments, weightsData))
}
