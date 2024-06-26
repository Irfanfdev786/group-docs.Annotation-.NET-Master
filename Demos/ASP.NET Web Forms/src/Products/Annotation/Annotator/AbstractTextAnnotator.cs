﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupDocs.Annotation.AspNetWebForms.Products.Annotation.Entity.Web;
using GroupDocs.Annotation.Models;

namespace GroupDocs.Annotation.AspNetWebForms.Products.Annotation.Annotator
{
    public abstract class AbstractTextAnnotator : BaseAnnotator
    {
        protected AbstractTextAnnotator(AnnotationDataEntity annotationData, PageInfo pageInfo)
            : base(annotationData, pageInfo)
        {

        }
        protected static List<Point> GetPoints(AnnotationDataEntity annotationData, PageInfo pageInfo)
        {
            return new List<Point>
            {
                new Point(annotationData.left, pageInfo.Height - annotationData.top),
                new Point(annotationData.left + annotationData.width, pageInfo.Height - annotationData.top),
                new Point(annotationData.left, pageInfo.Height - annotationData.top - annotationData.height),
                new Point(annotationData.left + annotationData.width, pageInfo.Height - annotationData.top - annotationData.height)
            };
        }

        protected static List<Point> GetPointsForImages(AnnotationDataEntity annotationData, PageInfo pageInfo)
        {
            return new List<Point>
            {
                new Point(annotationData.left, annotationData.top + annotationData.height),
                new Point(annotationData.left + annotationData.width, annotationData.top + annotationData.height),
                new Point(annotationData.left, annotationData.top),
                new Point(annotationData.left + annotationData.width, annotationData.top)
            };
        }
    }
}