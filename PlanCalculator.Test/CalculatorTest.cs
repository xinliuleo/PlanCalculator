using FluentAssertions;
using PlanCalculator.Models;
using PlanCalculator.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PlanCalculator.Test
{
    public class CalculatorTest
    {
        private readonly Calculator _calculator;

        public CalculatorTest()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Purchase_Price_Less_Than_100()
        {
            //arrange
            List<PlanOutput> expected = null;
            var inputPrice = 99;
            var inputDate = "2019-08-09";

            //act
            var result = _calculator.CalculatePaymentPlan(new PlanInput { Price = inputPrice, Date = inputDate });

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Purchase_Price_Greater_Than_100_But_Less_Than_1000()
        {
            //arrange
            var expected = new List<PlanOutput> {
                new PlanOutput{
                    Deposit = 0.2M,
                    InstalmentAmount = 16.16M,
                    InstalmentDates = new List<DateTime>{
                        new DateTime(2019,8,24),
                        new DateTime(2019, 9, 8),
                        new DateTime(2019, 9, 23),
                        new DateTime(2019, 10, 8),
                        new DateTime(2019, 10, 23)
                    }
                },
                new PlanOutput{
                    Deposit = 0.3M,
                    InstalmentAmount = 17.675M,
                    InstalmentDates = new List<DateTime>{
                        new DateTime(2019,8,24),
                        new DateTime(2019, 9, 8),
                        new DateTime(2019, 9, 23),
                        new DateTime(2019, 10, 8)
                    }
                }
            };
            var inputPrice = 101;
            var inputDate = "2019-08-09";

            //act
            var result = _calculator.CalculatePaymentPlan(new PlanInput {  Price = inputPrice, Date = inputDate });

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Purchase_Price_Is_1000()
        {
            //arrange
            var expected = new List<PlanOutput> {
                new PlanOutput{
                    Deposit = 0.2M,
                    InstalmentAmount = 160M,
                    InstalmentDates = new List<DateTime>{
                        new DateTime(2019,8,24),
                        new DateTime(2019, 9, 8),
                        new DateTime(2019, 9, 23),
                        new DateTime(2019, 10, 8),
                        new DateTime(2019, 10, 23)
                    }
                },
                new PlanOutput{
                    Deposit = 0.25M,
                    InstalmentAmount = 187.5M,
                    InstalmentDates = new List<DateTime>{
                        new DateTime(2019, 9, 8),
                        new DateTime(2019, 10, 8),
                        new DateTime(2019, 11, 7),
                        new DateTime(2019, 12, 7)
                    }
                },
                new PlanOutput{
                    Deposit = 0.3M,
                    InstalmentAmount = 175M,
                    InstalmentDates = new List<DateTime>{
                        new DateTime(2019,8,24),
                        new DateTime(2019, 9, 8),
                        new DateTime(2019, 9, 23),
                        new DateTime(2019, 10, 8)
                    }
                }
            };
            var inputPrice = 1000;
            var inputDate = "2019-08-09";

            //act
            var result = _calculator.CalculatePaymentPlan(new PlanInput { Price = inputPrice, Date = inputDate });

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Purchase_Price_Greater_Than_1000_But_Less_Than_10000()
        {
            //arrange
            var expected = new List<PlanOutput> {
                new PlanOutput{
                    Deposit = 0.25M,
                    InstalmentAmount = 187.6875M,
                    InstalmentDates = new List<DateTime>{
                        new DateTime(2019, 9, 8),
                        new DateTime(2019, 10, 8),
                        new DateTime(2019, 11, 7),
                        new DateTime(2019, 12, 7)
                    }
                }
            };
            var inputPrice = 1001;
            var inputDate = "2019-08-09";

            //act
            var result = _calculator.CalculatePaymentPlan(new PlanInput { Price = inputPrice, Date = inputDate });

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Purchase_Price_Greater_Than_10000()
        {
            //arrange
            List<PlanOutput> expected = null;
            var inputPrice = 10001;
            var inputDate = "2019-08-09";

            //act
            var result = _calculator.CalculatePaymentPlan(new PlanInput { Price = inputPrice, Date = inputDate });

            //assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
