package main

import (
	"fmt"
	"strconv"
)

type similMeasuresMat struct {
	estimations [][]int
	simSum      []int
}

type groupItems struct {
	item      int
	numGroup  int
	isInGroup bool
}

func createExpertsMat() [][]int {
	data := parseCsv("data.csv")
	expertsMatrix := make([][]int, len(data))
	for i := 0; i < len(expertsMatrix); i++ {
		expertsMatrix[i] = make([]int, len(data[0]))
	}
	for i := 0; i < len(expertsMatrix); i++ {
		for j := 0; j < len(expertsMatrix[0]); j++ {
			value, err := strconv.Atoi(data[i][j])
			if err != nil {
				fmt.Println("Error during conversion")
			}
			expertsMatrix[i][j] = value
		}
	}
	return expertsMatrix
}

func createSimilarityMeasuresMats(data [][]int) []similMeasuresMat {
	var result []similMeasuresMat
	for cmpLineIndex, _ := range data {
		var Mat similMeasuresMat
		for i, list := range data {
			line := make([]int, len(data[i]))
			var count = 0
			for j, item := range list {
				if item == data[cmpLineIndex][j] {
					line[j] = 1
					count++
				} else {
					line[j] = 0
				}
			}
			Mat.estimations = append(Mat.estimations, line)
			Mat.simSum = append(Mat.simSum, count)
		}
		result = append(result, Mat)
	}
	return result
}

func createSimMat(allSimilarity []similMeasuresMat) [][]float64 {
	result := make([][]float64, len(allSimilarity))
	for i, _ := range result {
		line := make([]float64, len(result))
		result[i] = append(result[i], line...)
	}
	var divider = float64(len(allSimilarity[0].estimations[0]))
	for colIndex, mat := range allSimilarity {
		for j, sum := range mat.simSum {
			result[colIndex][j] = float64(sum) / divider
		}
	}
	return result
}

func giveGroup(mat *[][]float64, line *[]float64, splittingThreshold *float64, experts *[]groupItems, countGroup *int, isAdded *bool) {
	for j, item := range *line {
		if item >= *splittingThreshold && !(*experts)[j].isInGroup {
			(*experts)[j].isInGroup = true
			(*experts)[j].numGroup = *countGroup
			*isAdded = true
			giveGroup(mat, &((*mat)[j]), splittingThreshold, experts, countGroup, isAdded)
		}
	}
}

func createGroupSplitting(mat [][]float64, splittingThreshold float64) [][]int {
	experts := make([]groupItems, len(mat))
	var countGroup = 1
	var isAdded bool
	for i := 0; i < len(mat); i++ {
		giveGroup(&mat, &(mat)[i], &splittingThreshold, &experts, &countGroup, &isAdded)
		if isAdded {
			countGroup++
			isAdded = false
		}
	}

	//forming group
	var groups [][]int
	for i := 1; i < countGroup; i++ {
		var group []int
		for j, item := range experts {
			if item.numGroup == i {
				group = append(group, j+1)
			}
		}
		groups = append(groups, group)
	}

	return groups
}

func printGroups(groups [][]int) {
	for i, list := range groups {
		fmt.Print(i+1, ") ")
		for _, item := range list {
			fmt.Print(item, " ")
		}
		fmt.Println()
	}
}

func main() {
	estimates := createExpertsMat()
	allSimilarity := createSimilarityMeasuresMats(estimates)
	simMat := createSimMat(allSimilarity)
	groups := createGroupSplitting(simMat, 0.5)
	printGroups(groups)
}
