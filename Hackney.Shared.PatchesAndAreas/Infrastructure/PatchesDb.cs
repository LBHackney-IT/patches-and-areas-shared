using Amazon.DynamoDBv2.DataModel;
using Hackney.Core.DynamoDb.Converters;
using Hackney.Shared.PatchesAndAreas.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackney.Shared.PatchesAndAreas.Infrastructure
{
    [DynamoDBTable("PatchesAndAreas", LowerCamelCaseProperties = true)]
    public class PatchesDb
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey]
        public Guid ParentId { get; set; }

        [DynamoDBProperty]
        public string Name { get; set; }

        [DynamoDBProperty(Converter = typeof(DynamoDbEnumConverter<PatchType>))]
        public PatchType PatchType { get; set; }

        [DynamoDBProperty]
        public string Domain { get; set; }

        [DynamoDBProperty(Converter = typeof(DynamoDbObjectListConverter<ResponsibleEntities>))]
        public List<ResponsibleEntities> ResponsibleEntities { get; set; }

        [DynamoDBVersion]
        public int? VersionNumber { get; set; }

    }
}
